using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Website_first_build.Filter
{
    public class StringExtensions
    {
        public static IEnumerable<string> SplitIntoParagraphs(string text, int maxLength = 500)
        {
            if (string.IsNullOrEmpty(text)) yield break;

            var words = text.Split(' ');
            var currentParagraph = new StringBuilder();

            foreach (var word in words)
            {
                if(currentParagraph.Length + word.Length > maxLength)
                {
                    yield return currentParagraph.ToString().Trim();
                    currentParagraph.Clear();
                }
                currentParagraph.Append(word + " ");
            }
            if (currentParagraph.Length > 0) yield return currentParagraph.ToString().Trim();
        }
    }
}