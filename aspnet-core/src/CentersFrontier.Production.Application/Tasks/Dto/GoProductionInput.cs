﻿using Abp.Application.Services.Dto;

namespace CentersFrontier.Production.Tasks.Dto
{
    public class GoProductionInput : EntityDto<long>
    {
        public int Quantity { get; set; }
    }
}