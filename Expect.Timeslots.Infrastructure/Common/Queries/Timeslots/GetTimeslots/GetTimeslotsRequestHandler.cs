using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Enums;
using Expect.Timeslots.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Timeslots.GetTimeslots
{
    public class GetTimeslotsRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase<GetTimeslotsRequest>(mapper, context)
    {
        private const int MinutesPerPallet = 5;
        private const int TimeParity = 30;
        private readonly TimeOnly GateStartTime = new(0, 0);
        private readonly TimeOnly GateEndTime = new(23, 0);


        public override async Task<OperationResult> Handle(GetTimeslotsRequest request, CancellationToken cancellationToken)
        {
            var pallets = request.Dto.Pallets;
            var timeslotDate = request.Dto.Date;

            var freeTimeslots = new List<Timeslot>();
            var nearbyDays = new List<DateOnly>()
            {
                timeslotDate.AddDays(-1),
                timeslotDate,
                timeslotDate.AddDays(1),
            };

            
            var minutesNeeded = GetNeededMinutes(pallets);
            var gateId = (await _context.Gates.FirstOrDefaultAsync(cancellationToken)).Id;

            foreach (var day in  nearbyDays)
            {
                var currentTime = new DateTime(day, GateStartTime);
                var gateEnd = new DateTime(day, GateEndTime);

                while (currentTime.AddMinutes(minutesNeeded) < gateEnd)
                {
                    var currentTimeOnly = new TimeOnly(currentTime.Hour, currentTime.Minute);
                    var timeslot = new Timeslot
                    {
                        Id = Guid.NewGuid(),
                        Date = day,
                        GateId = gateId,
                        TaskType = TaskType.Loading,
                        From = currentTimeOnly,
                        To = currentTimeOnly.AddMinutes(minutesNeeded)
                    };

                    freeTimeslots.Add(timeslot);

                    currentTime = currentTime.AddMinutes(minutesNeeded); 
                }
            }

            return new OperationResult(StatusCodes.Status200OK, freeTimeslots);
        }

        private int GetNeededMinutes(int pallets)
        {
            var minutesNeeded = pallets * MinutesPerPallet;
            return (int)Math.Ceiling(minutesNeeded / (float)TimeParity) * TimeParity;
        }
    }
}
