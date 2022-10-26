//Pedro Castaneda
//10-26-2022
//Reverse It - Endpoint
//created enpoint that will call a function to reverse a word or number
//Peer Review by; 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace castanedaPReverseItEndpoint.Controllers
{
    [Route("[controller]")]
    public class ReverseController : Controller
    {
        [HttpGet]
        [Route("Reverse/{wordNum}")]

        public string ReverseIt(string wordNum)
        {
            string result = "";
            int num = 0;
            bool checkNum = Int32.TryParse(wordNum, out num);
            if(!checkNum)
            {
                for(int i = wordNum.Length - 1; i >= 0; i--)
                {
                   result += wordNum[i];
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