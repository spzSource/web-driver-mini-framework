using ATFramework.Framework.Attributes;

namespace TimeAndDateAutomation.WebPages.Blocks
{
	[NameAttribute("Home")]
	public enum Home
	{
		[NameAttribute("Newsletter")]
		Newsletter,

		[NameAttribute("About Us")]
		About_Us,

		[NameAttribute("Site Map")]
		Site_Map
	}

	[NameAttribute("World Clock")]
	public enum World_Clock
	{
		[NameAttribute("Main World Clock")]
		Main_World_Clock,

		[NameAttribute("Extended World Clock")]
		Extended_World_Clock,

		[NameAttribute("Personal World Clock")]
		Personal_World_Clock,

		[NameAttribute("Event Time Announcer")]
		Event_Time_Announcer
	}

	[NameAttribute("Time Zones")]
	public enum Time_Zones
	{
		[NameAttribute("Time Zone Converter")]
		Time_Zone_Converter,

		[NameAttribute("Meeting Planner")]
		Meeting_Planner,

		[NameAttribute("Time Zone Map")]
		Time_Zone_Map,

		[NameAttribute("Time Zone Abbreviations")]
		Time_Zone_Abbreviations,

		[NameAttribute("Time Zone News")]
		Time_Zone_News,

		[NameAttribute("Daylight Saving Time")]
		Daylight_Saving_Time
	}
}
