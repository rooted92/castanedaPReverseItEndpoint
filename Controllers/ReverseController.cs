//Pedro Castaneda
//10-26-2022
//Reverse It - Endpoint
//created enpoint that will call a function to reverse a word or number
//Peer Review by; Marcel R - The program worked well, it took a string and used a model for the input through JSON on Postman, and output it reversed. Solid implementation and well written! :D
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using castanedaPReverseItEndpoint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace castanedaPReverseItEndpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReverseController : ControllerBase
    {
        [HttpGet("Reverse")]

        public string ReverseIt(ReverseModel input)
        {
            string result = "";
            int num = 0;
            bool checkNum = Int32.TryParse(input.wordNum, out num);
            if(!checkNum)
            {
                for(int i = input.wordNum.Length - 1; i >= 0; i--)
                {
                   result += input.wordNum[i];
                }
                result = $"{result}";
            }
            else if(checkNum)
            {
                int reverse = 0;
                int remainder = 0;
                while(num > 0)
                {
                    remainder = num % 10;
                    reverse = (reverse * 10) + remainder;
                    num = num/10;
                }
                result = $"{reverse}";
            }
            return result;
        }
    }
}