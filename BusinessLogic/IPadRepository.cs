using System;

namespace BusinessLogic
{
    interface IPadRepository
    {
        void AddPad(Pad pad);

        Pad GetPadById(Guid id);
    }
}
