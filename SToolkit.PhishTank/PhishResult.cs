using System;

namespace SToolkit.PhishTank
{
    public class PhishResult
    {
        /// <summary>
        /// Checked url.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// False, if the url is not in the site database.
        /// </summary>
        public bool InDatabase { get; set; }
        /// <summary>
        /// Return true if site is phishing
        /// </summary>
        public bool IsPhish { get; set; }
        /// <summary>
        /// The ID number by which Phishtank refers to a phish submission. All data in PhishTank is tied to this ID.
        /// </summary>
        public int PhishID { get; set; }
        /// <summary>
        /// PhishTank detail url for the phish, where you can view data about the phish, including a screenshot and the community votes.
        /// </summary>
        public string PhishPage { get; set; }
        /// <summary>
        /// Whether or not this phish has been verified by our community.
        /// </summary>
        public bool Verified { get; set; }
        /// <summary>
        /// The date and time at which the phish was verified as valid by our community. This is an ISO 8601 formatted date.
        /// </summary>
        public DateTime VerifiedDate { get; set; }
    }
}
