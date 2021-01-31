using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

interface ILevelParametersContainer
{
    UnityAction<Parameters> OnLevelParametersChanged { get; set; }
}
