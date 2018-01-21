using Android.Support.V7.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace FPOW.Droid
{
    internal class ThanksFragment : AppCompatDialogFragment
    {
        private TextView _thanksTextView;

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var view = LayoutInflater.From(Activity).Inflate(Resource.Layout.fragment_thanks, null);

            _thanksTextView = view.FindViewById<TextView>(Resource.Id.thanksTextView);
            _thanksTextView.Text = "����������: " + "�. �������� (��.)" + "\n" +
                "������� ��� ����: " + "�. �������� (��.)" + "\n" + "\n" +
                "�������������:" + "\n" + 
                "��������� �." + "\n" +
                "������ �." + "\n" +

                "\n" + "(����� ����� �������� ���, ��������� ��� ��������� � ������)";

            var dialog = new Android.Support.V7.App.AlertDialog.Builder(Activity, Resource.Style.AlertDialogTheme)
                .SetTitle("�������������")
                .SetView(view)
                .SetPositiveButton("�������", ConfirmButtonClicked)
                .SetCancelable(false)
                .Create();
            
            return dialog;
        }

        public static ThanksFragment NewInstance()
        {
            var args = new Bundle();

            return new ThanksFragment { Arguments = args };
        }

        private void ConfirmButtonClicked(object sender, DialogClickEventArgs e)
        {
            ((Android.Support.V7.App.AlertDialog)sender).Dismiss();
        }
    }
}