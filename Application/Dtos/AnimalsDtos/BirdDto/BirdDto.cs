﻿namespace Application.Dtos.AnimalsDtos.BirdDto
{
    public class BirdDto : AnimalDto
    {
        public bool CanFly { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}