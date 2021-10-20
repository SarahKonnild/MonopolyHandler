using Microsoft.AspNetCore.Mvc;
using Monopoly.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.API
{
    class GameController
    {

        [HttpPost]
        public void StartGame([FromBody] List<Player> players) { 
            
        
        } 

    }
}
