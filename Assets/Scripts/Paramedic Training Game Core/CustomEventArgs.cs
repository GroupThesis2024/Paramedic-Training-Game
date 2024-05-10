using System;

namespace Backend
{
    public class CustomEventArgs : EventArgs
    {
        public PatientFactory patientFactoryInstance { get; }

        public CustomEventArgs(PatientFactory instance)
        {
            patientFactoryInstance = instance;
        }
    }
}
