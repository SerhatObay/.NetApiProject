﻿namespace Entities.Exceptions
{
    public class PriceOutOfRangeBadRequestException : BadRequestException
    {
        public PriceOutOfRangeBadRequestException() 
            : base("Maximum price should be less than 1000 an greater than 10.")
        {

        }
    }
}
