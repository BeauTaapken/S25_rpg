﻿using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Interface
{
    public interface ICharacterCollectionRepo
    {
        ICharacter AddCharacter(ICharacter character, int id);

        
    }
}