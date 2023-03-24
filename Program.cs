/* This program using simple logic using predefined array*/
/* Using same command as given examples */
/* Defined logic works well on one time test */
/* Exception handler needed for continuous test / lacking in validation */
/* Need to declare object separately to accesss its value then join as another type */
/* Do implement database or dictionary for best practices, more suitable because the key and value */

public class Parking
{
	public static void Main(string[] args)
	{		
		string[] parkingLots = new string[6];
		parkingLots[0] = "1"; /* row n + 1 */
		parkingLots[1] = "2"; /* similar to n + 1 problem */
		parkingLots[2] = "3";
		parkingLots[3] = "";
		parkingLots[4] = "";

		string[] vehicleIdentities = new string[5];
		vehicleIdentities[0] = "Z-444-FZ";
		vehicleIdentities[1] = "Z-575-SK";
		vehicleIdentities[2] = "F-788-PO";
		vehicleIdentities[3] = "";
		vehicleIdentities[4] = "";

		string[] vehicleTypes = new string[5];
		vehicleTypes[0] = "Mobil";
		vehicleTypes[1] = "Motor";
		vehicleTypes[2] = "Mobil";
		vehicleTypes[3] = "";
		vehicleTypes[4] = "";

		string[] vehicleColors = new string[5];	
		vehicleColors[0] = "Hitam";
		vehicleColors[1] = "Putih";
		vehicleColors[2] = "Putih";
		vehicleColors[3] = "";
		vehicleColors[4] = "";

		string closeProgram = "null"; 
		while(true)
		{
			if (closeProgram == "exit")
			{
				break;
			}
			
			Console.WriteLine("Full Command");
			string userInput = Console.ReadLine();
			string[] cmd = userInput.Split(' ');
			closeProgram = cmd[0];


			if (cmd[0] == "create_parking_lot")
			{
				/* Different array pointer because returning new array */
				int slot = Convert.ToInt32(cmd[1]);
				Array.Resize(ref parkingLots, slot);
				Array.Resize(ref vehicleIdentities, slot);
				Array.Resize(ref vehicleTypes, slot);
				Array.Resize(ref vehicleColors, slot);
				Console.WriteLine("Create a parking lot with {0} slot", slot);
				/* For learning purposes */
			}
			if (cmd[0] == "leave") {
				int slot = Convert.ToInt32(cmd[1]);
				parkingLots[slot] = "";
				vehicleIdentities[slot] = "";
				vehicleTypes[slot] = "";								
				vehicleColors[slot] = "";
				slot += 1;
				Console.WriteLine("Slot number {0} is free", slot);				
			}
			/* As expected for not using key and value mapping, command working but n+1 or n-1 */
			/* Better to implement database */
			if (cmd[0] == "park") {
				/* Set lot with predefined*/
				parkingLots[4] = "5";
				int slot = Convert.ToInt32(parkingLots[4]);
				/* Might need randomizer */
				vehicleIdentities[4] = cmd[1];
				vehicleTypes[4] = cmd[2];
				vehicleColors[4] = cmd[3];
				Console.WriteLine("Allocated slot number: {0}", slot);
			}

			if (cmd[0] == "types_of_vehicles") {
				int countVehicles = 0;
				int[] counted = new int[1];
				for (int i = 0; i < vehicleTypes.Length; i++)
				{
					if(vehicleTypes[i].Contains(cmd[1]))
					{
						countVehicles++;
					}
					/* Make sure value passed */
					continue;
				}
				Console.WriteLine(countVehicles);
			}
			if (cmd[0] == "registration_numbers_for_vehicles_with_event_plate") {
				foreach (string s in vehicleIdentities)
				{
					string[] even = s.Split('-');
					int findEven = Convert.ToInt32(even[1]);
					if (findEven%2==0) {
						Console.Write(s + ", ");
					}
				}
			}
			if (cmd[0] == "registration_numbers_for_vehicles_with_ood_plate") {
				foreach (string s in vehicleIdentities)
				{
					string[] odd = s.Split('-');
					int findOdd = Convert.ToInt32(odd[1]);
					if (findOdd%2==1) {
						Console.Write(s + ", ");
					}
				}
			}
			if (cmd[0] == "registration_numbers_for_vehicles_with_colour") {
				for (int i = 0; i < vehicleColors.Length; i++)
				{
					if(vehicleColors[i].Contains(cmd[1]))
					{
						Console.WriteLine(vehicleIdentities[i] + ", ");
					}
				}
			}
			if (cmd[0] == "slot_number_for_registration_number") {
				for (int i = 0; i < vehicleIdentities.Length; i++)
				{
					if(vehicleIdentities[i].Contains(cmd[1]))
					{
						Console.WriteLine(i+1);
					}
				}
			}
			if (cmd[0] == "slot_number_for_vehicles_with_colour")
			{
				for (int i = 0; i < vehicleColors.Length; i++)
				{
					if(vehicleColors[i].Contains(cmd[1]))
					{
						/* Need to implement iteration and formatting more */
						Console.Write((i+1)+", ");
					}
				}
			}
			if (cmd[0] == "status")
			{
				string tabs = "			";
				Console.WriteLine("Slot No.{0}Registration No.{1}Vehicle Types.{2}Vehicle Colors.{3}", tabs, tabs, tabs, tabs);
				int z = 0;

				/* Removing null */
				List<string> temp = new List<string>();
				foreach (string s in parkingLots)
				{
					if(!string.IsNullOrEmpty(s))
						temp.Add(s);
				}
				parkingLots = temp.ToArray();

				List<string> temp1 = new List<string>();
				foreach (string s in vehicleIdentities)
				{
					if(!string.IsNullOrEmpty(s))
						temp1.Add(s);
				}
				vehicleIdentities = temp1.ToArray();

				List<string> temp2 = new List<string>();
				foreach (string s in vehicleTypes)
				{
					if(!string.IsNullOrEmpty(s))
						temp2.Add(s);
				}
				vehicleTypes = temp2.ToArray();

				List<string> temp3 = new List<string>();
				foreach (string s in vehicleColors)
				{
					if(!string.IsNullOrEmpty(s))
						temp3.Add(s);
				}
				vehicleColors = temp3.ToArray();

				/* Best practices */
				/* Must create an object for null filtering */
				foreach(string s in parkingLots)
				{
						Console.WriteLine(parkingLots[z] + tabs + "	" + vehicleIdentities[z] + tabs + "	" + vehicleTypes[z] + tabs + "	" + vehicleColors[z]);
						z += 1;						
				}
				/* For learning purposes */
			}
		}

	}
}

/* Something that's I figured out */
/* Using leave 0 removing array at first index, and moving second index to first */
/* Because when I did again leave 0 it also removing lot number 2 with message removing lot number 1 */

/* Date Time logic using span time, and declare variable as span time in hour */
/* What an experience */