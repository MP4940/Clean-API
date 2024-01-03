﻿using Application.Dtos.AnimalUserDto;
using Domain.Models.AnimalUsers;
using MediatR;

namespace Application.Commands.AnimalUsers
{
    public class CreateAnimalUserCommand : IRequest<AnimalUser>
    {
        public CreateAnimalUserCommand(AnimalUserDto animalUserDto)
        {
            AnimalUserDto = animalUserDto;
        }
        public AnimalUserDto AnimalUserDto { get; }
    }
}