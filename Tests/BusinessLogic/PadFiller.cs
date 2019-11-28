using BusinessLogic;

namespace Tests.BusinessLogic
{
    internal class PadFiller
    {
        public static Pad GetFullPad()
        {
            var pad = new Pad();
            const int totalCountTasks = 100;

            for (var taskIndex = 0; taskIndex < totalCountTasks; taskIndex++)
            {
                var task = new Task();
                task.Caption = $"Task number: {taskIndex}";
                pad.AddTask(task);
            }

            return pad;
        }
    }
}
