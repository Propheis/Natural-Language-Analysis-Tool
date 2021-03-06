﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLA_Tool.Trees
{
    /// <summary>
    /// Represents the intermediate (X') node of a phrase structure.
    /// </summary>
    class Intermediate
    {
        #region Public Properties
        /// <summary>
        /// Required - The head of the intermediate phrase
        /// </summary>
        public Terminal Head { get; set; }

        /// <summary>
        /// Optional - A nested phrase
        /// </summary>
        public Phrase Complement { get; set; }

        /// <summary>
        /// True if <see cref="Complement"/> is not null.
        /// </summary>
        public bool hasComplement { get { return (Complement != null); } }

        public PhraseCategory PhraseCategory { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of Intermediate
        /// </summary>
        /// <param name="head">The head of the intermediate phrase</param>
        public Intermediate(Terminal head)
        {
            Head = head;
            setPhraseCategory();
        }

        /// <summary>
        /// Creates a new instance of Intermediate
        /// </summary>
        /// <param name="head">The head of the intermediate phrase</param>
        /// <param name="Complement">The complement phrase to attach</param>
        public Intermediate(Terminal head, Phrase Complement)
            : this(head)  // Constructor chaining see http://stackoverflow.com/questions/829870/calling-constructor-from-other-constructor-in-same-class
        {
            this.Complement = Complement;
        } 
        #endregion

        #region Private Methods

        /// <summary>
        /// Figures out what the value of X' should be based on the lexical category of the head.
        /// <remarks>Note: <c>Head</c> must be initialized before using this method</remarks>
        /// </summary>
        /// <returns>The appropriate <c>PhraseCategory</c> of the Intermediate Phrase</returns>
        private void setPhraseCategory()
        {
            switch (Head.Category)
            {
                case LexicalCategory.Noun:
                    PhraseCategory = Trees.PhraseCategory.NP;
                    break;
                case LexicalCategory.Verb:
                    PhraseCategory = Trees.PhraseCategory.VP;
                    break;
                case LexicalCategory.Adjective:
                    PhraseCategory = Trees.PhraseCategory.AP;
                    break;
                case LexicalCategory.Adverb:
                    PhraseCategory = Trees.PhraseCategory.AdvP;
                    break;
                case LexicalCategory.Preposition:
                    PhraseCategory = Trees.PhraseCategory.PP;
                    break;
                case LexicalCategory.Determiner:
                    PhraseCategory = Trees.PhraseCategory.DP;
                    break;
                case LexicalCategory.Auxilliary:
                    PhraseCategory = Trees.PhraseCategory.AP;
                    break;
                case LexicalCategory.Pronoun:
                    PhraseCategory = Trees.PhraseCategory.NP;
                    break;
                case LexicalCategory.Punctuation:
                    throw new Exception("Punctuation cannot be the head of an intermediate phrase.");
                default:
                    break;
            }
        }

        #endregion
    }
}
