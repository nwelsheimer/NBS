//This is a source code or part of OpenMiracle project
//Copyright (C) 2013 OpenMiracle
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//GNU General Public License for more details.
//You should have received a copy of the GNU General Public License
//along with this program. If not, see <http://www.gnu.org/licenses/>.
#region Using
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
#endregion


namespace BaseWPFHelpers
{
    public class Helpers
    {
    

        /// <summary>
        /// Base Interface that describes the visual match pattern
        /// Part of the Visual tree walkers
        /// </summary>
        public interface IFinderMatchVisualHelper
        {
            /// <summary>
            /// Does this item match the input visual item
            /// </summary>
            /// <param name="item">Item to check </param>
            /// <returns>True if matched, else false</returns>
            bool DoesMatch(DependencyObject item);

            /// <summary>
            /// Property that defines if we should stop walking the tree after the first match is found
            /// </summary>
            bool StopAfterFirst
            {
                get;
                set;
            }
        }

        /// <summary>
        /// Visual tree walker class that matches based on Type
        /// </summary>
        public class FinderMatchType : IFinderMatchVisualHelper
        {
            private Type _ty = null;
            private bool _stopafterfirst = false;

            public FinderMatchType(Type ty)
            {
                _ty = ty;
            }

            public FinderMatchType(Type ty, bool StopAfterFirst)
            {
                _ty = ty;
                _stopafterfirst = StopAfterFirst;
            }

            public bool DoesMatch(DependencyObject item)
            {
                return _ty.IsInstanceOfType(item);
            }

            public bool StopAfterFirst
            {
                get
                {
                    return _stopafterfirst;
                }
                set
                {
                    _stopafterfirst = value;
                }
            }
        }



        /// <summary>
        /// All way visual tree helper that searches UP and DOWN in a tree for the matching pattern.
        /// 
        /// This is used to walk for name matches or type matches typically.
        /// 
        /// Returns only the first matching element
        /// </summary>
        /// <param name="parent">Start point in the tree to search</param>
        /// <param name="helper">Match Helper to use</param>
        /// <returns>Null if no match, else returns the first element that matches</returns>
        public static FrameworkElement SingleFindInTree(Visual parent, IFinderMatchVisualHelper helper)
        {
            helper.StopAfterFirst = true;

            List<FrameworkElement> lst = FindInTree(parent, helper);

            FrameworkElement feRet = null;

            if (lst.Count > 0) feRet = lst[0];

            return feRet;
        }

      

        /// <summary>
        /// Walker that looks both UP and down in the visual tree for any matching elements, typically used with Type
        /// </summary>
        /// <param name="parent">Start point in the tree to search</param>
        /// <param name="helper">Match Helper to use</param>
        /// <returns>List of matching FrameworkElements</returns>
        public static List<FrameworkElement> FindInTree(Visual parent, IFinderMatchVisualHelper helper)
        {
            List<FrameworkElement> lst = new List<FrameworkElement>();

            FindUpInTree(lst, parent, null, helper);

            return lst;
        }



        /// <summary>
        /// Really a helper to look Up in a tree, typically not called directly.
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="parent"></param>
        /// <param name="ignore"></param>
        /// <param name="helper"></param>
        public static void FindUpInTree(List<FrameworkElement> lst, Visual parent, Visual ignore, IFinderMatchVisualHelper helper)
        {
            // First thing to do is find Down in the existing node...
            //FindDownInTree(lst, parent, ignore, helper);

            if (helper.DoesMatch(parent))
            {
                lst.Add(parent as FrameworkElement);
            }


            // Ok, now check to see we are not at a stop.. i.e. got it.
            if (lst.Count > 0 && helper.StopAfterFirst)
            {
                // Hum, don't think we need to do anything here: yet.
            }
            else
            {
                // Ok, now try to get a new parent...
                FrameworkElement feCast = parent as FrameworkElement;
                if (feCast != null)
                {
                    FrameworkElement feNewParent = feCast.Parent as FrameworkElement;
                    if (feNewParent == null || feNewParent == feCast)
                    {
                        // Try to get the templated parent
                        feNewParent = feCast.TemplatedParent as FrameworkElement;
                    }

                    // Now check to see that we have a valid parent
                    if (feNewParent != null && feNewParent != feCast)
                    {
                        // Pass up
                        FindUpInTree(lst, feNewParent, feCast, helper);
                    }
                }
            }
        }


    
        /// <summary>
        /// Simple form call that returns the first element of a given type up in the visual tree
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="ty"></param>
        /// <returns></returns>
        public static FrameworkElement FindElementOfTypeUp(Visual parent, Type ty)
        {
            return SingleFindInTree(parent, new FinderMatchType(ty));
        }
        
     

     

    }

}
