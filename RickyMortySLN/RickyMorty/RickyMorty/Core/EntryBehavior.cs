using Xamarin.Forms;

namespace RickyMorty.Core
{
    public class EntryBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += Entry_TextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= Entry_TextChanged;
            base.OnDetachingFrom(entry);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (NativeEntry)sender;
            if (entry.Text.Length % 3 == 0) entry.TextColor = Color.Red; else entry.TextColor = Color.Black;
        }
    }
}
