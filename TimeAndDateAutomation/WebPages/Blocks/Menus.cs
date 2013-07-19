using ATFramework.Framework.Attributes;

namespace TimeAndDateAutomation.WebPages.Blocks
{
	[NameAttribute("Home")]
	public enum Home
	{
		[NameAttribute("Newsletter")]
		Newsletter,

		[NameAttribute("About Us")]
		AboutUs,

		[NameAttribute("Site Map")]
		SiteMap
	}

	[NameAttribute("World Clock")]
	public enum WorldClock
	{
		[NameAttribute("Main World Clock")]
		MainWorldClock,

		[NameAttribute("Extended World Clock")]
		ExtendedWorldClock,

		[NameAttribute("Personal World Clock")]
		PersonalWorldClock,

		[NameAttribute("Event Time Announcer")]
		EventTimeAnnouncer
	}

	[NameAttribute("Time Zones")]
	public enum TimeZones
	{
		[NameAttribute("Time Zone Converter")]
		TimeZoneConverter,

		[NameAttribute("Meeting Planner")]
		MeetingPlanner,

		[NameAttribute("Time Zone Map")]
		TimeZoneMap,

		[NameAttribute("Time Zone Abbreviations")]
		TimeZoneAbbreviations,

		[NameAttribute("Time Zone News")]
		TimeZoneNews,

		[NameAttribute("Daylight Saving Time")]
		DaylightSavingTime
	}
}
