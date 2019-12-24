using BusinessLogic;

namespace Tests.BusinessLogic
{
    internal class PadFiller
    {
        public static Pad GetFullPad(int totalTasksCount = 100)
        {
            var pad = new Pad();

            for (var taskIndex = 0; taskIndex < totalTasksCount; taskIndex++)
            {
                var task = new Task
                {
                    Caption = $"Task number: {taskIndex}",
                    Link = $"examplelink.com/{taskIndex}",
                    Addition = $"Additional info for {taskIndex}"
                };

                pad.AddTask(task);
            }

            return pad;
        }
    }
}
