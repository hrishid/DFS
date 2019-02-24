using DFS.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFS.ViewModel
{
   public class DisplayCiCardViewModel :BaseViewModel
    {

        public DisplayCiCardViewModel()
        {
            IGetCards getCards = new GetCardService();

          
        }
    }
}
