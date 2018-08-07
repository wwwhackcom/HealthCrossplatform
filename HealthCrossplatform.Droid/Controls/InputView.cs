using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace HealthCrossplatform.Droid.Controls
{
    public class InputView : RelativeLayout
    {
        private TextView _label;
        private EditText _info;

        public InputView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(attrs);
        }

        public string Label
        {
            get => _label.Text;
            set => _label.Text = value;
        }

        public string Info
        {
            get => _info.Text;
            set => _info.Text = value;
        }

        private void Init(IAttributeSet attrs)
        {
            var inflater = LayoutInflater.From(Context);
            var layout = inflater.Inflate(Resource.Layout.control_input_view, this);

            _label = layout.FindViewById<TextView>(Resource.Id.label);
            _info = layout.FindViewById<EditText>(Resource.Id.info);
        }
    }
}
