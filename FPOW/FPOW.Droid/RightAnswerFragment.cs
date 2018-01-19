using Android.Support.V7.App;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Content;
using Android.Content;
using System;
using System.Threading.Tasks;

namespace FPOW.Droid
{
    internal class RightAnswerFragment : AppCompatDialogFragment
    {
        private const string _rightWordTag = nameof(_rightWordTag);
        private string _word;
        private TextView _titleTextView;
        private TextView _wordTextView;

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var view = LayoutInflater.From(Activity).Inflate(Resource.Layout.fragment_right_word, null);

            _titleTextView = view.FindViewById<TextView>(Resource.Id.title);
            _wordTextView = view.FindViewById<TextView>(Resource.Id.word);

            _word = Arguments.GetString(_rightWordTag);

            _titleTextView.Text = Resources.GetString(Resource.String.CorrectToastText);
            _wordTextView.Text = _word;

            var dialog = new Android.Support.V7.App.AlertDialog.Builder(Activity, Resource.Style.RightWordDialog)
                .SetView(view)
                .SetPositiveButton(Resources.GetString(Resource.String.CloseButton), CloseDialog)
                .SetCancelable(false)
                .Create();
            
            return dialog;
        }

        private void CloseDialog(object sender, DialogClickEventArgs e)
        {
            ((Android.Support.V7.App.AlertDialog)sender).Dismiss();
        }

        public static RightAnswerFragment NewInstance(string word)
        {
            var args = new Bundle();
            args.PutString(_rightWordTag, word);

            return new RightAnswerFragment { Arguments = args };
        }
    }
}