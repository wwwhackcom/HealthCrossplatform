using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace HealthCrossplatform.Droid.Controls
{
    public class InputView : RelativeLayout
    {
        private TextView _label;
        private EditText _input;

        public InputView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(attrs);
        }

        public string Label
        {
            get => _label.Text;
            set => _label.Text = value;
        }

        public string Input
        {
            get => _input.Text;
            set => _input.Text = value;
        }

        private void Init(IAttributeSet attrs)
        {
            var inflater = LayoutInflater.From(Context);
            var layout = inflater.Inflate(Resource.Layout.control_input_view, this);

            _label = layout.FindViewById<TextView>(Resource.Id.label);
            _input = layout.FindViewById<EditText>(Resource.Id.info);
        }
    }
}
