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
                var task = new Task();
                task.Caption = $"Task number: {taskIndex}";
                pad.AddTask(task);
            }

            return pad;
        }
    }
}
