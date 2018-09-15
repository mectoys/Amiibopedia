using System;
using System.Collections.Generic;
using System.Text;

namespace Amiibopedia.Models
{

    //modelo de datos
    //copias el Json Completo 
    //en VS en edit/pegado especial/pegar JSON con clase

    public class Characters
    {
        #region Attributtes
        public Character[] amiibo { get; set; } 
        #endregion
    }

    #region Properties

    public class Character
    {
        public string key { get; set; }
        public string name { get; set; }
    } 
    #endregion

}
