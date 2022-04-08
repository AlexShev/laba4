using laba4.Decorators;
using laba4.Professions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4.DogManegers;

public interface IDogMeneger
{
    bool CanMakeOlder(Puppy puppy);
    AdultDog? MakeOlder(Puppy puppy);
    bool CanMakeOlder(AdultDog adultDog);
    OldDog? MakeOlder(AdultDog adultDog);

}
