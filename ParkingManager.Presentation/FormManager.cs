using System.Windows.Forms;

namespace ParkingManager.Presentation
{
    public abstract class FormManager
    {
        public abstract void Add();

        public abstract UserControl GetAll();
        
        public abstract void Delete();

        public abstract void Update();

    }
}
