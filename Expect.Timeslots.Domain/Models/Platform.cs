﻿using Expect.Timeslots.Domain.Interfaces;

namespace Expect.Timeslots.Domain.Models
{
    public class Platform : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IReadOnlyCollection<Gate>? Gates { get; set; }
    }
}
