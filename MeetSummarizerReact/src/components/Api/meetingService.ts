// import axios from "axios";

// const BASE_URL = "https://localhost:7214/api/Meeting";

// // פונקציה לקבלת ה-Token מה-LocalStorage
// const getAuthToken = () => localStorage.getItem("token");

// export interface Meeting {
//   id: number;
//   name: string;
//   date: string;
// }

// export const fetchMeetings = async (): Promise<Meeting[]> => {
//   try {
//     // /Admin kvuxh; tjrh BASEURL בשורה מתחת
//     const response = await axios.get<Meeting[]>(`${BASE_URL}`, {
//       headers: {
//         Authorization: `Bearer ${getAuthToken()}`,
//       },
//     });
//     return response.data;
//   } catch (error) {
//     console.error("Error fetching meetings:", error);
//     return [];
//   }
// };




// export const addMeeting = async (meeting: Omit<Meeting, "id"> & { userIds: number[] }): Promise<Meeting | null> => {
//   try {
//     const response = await axios.post<Meeting>(
//       `${BASE_URL}`,
//       meeting, // כעת הנתונים כוללים UserIds
//       {
//         headers: {
//           Authorization: `Bearer ${getAuthToken()}`,
//           "Content-Type": "application/json",
//         },
//       }
//     );
//     return response.data;
//   } catch (error) {
//     console.error("Error adding meeting:", error);
//     return null;
//   }
// };











// // export const addMeeting = async (meeting: Omit<Meeting, "id">): Promise<Meeting | null> => {
// //   try {
// //     const response = await axios.post<Meeting>(
// //       `${BASE_URL}`,
// //       meeting,
// //       {
// //         headers: {
// //           Authorization: `Bearer ${getAuthToken()}`, // הוספת טוקן
// //         },
// //       }
// //     );
// //     return response.data;
// //   } catch (error) {
// //     console.error("Error adding meeting:", error);
// //     return null;
// //   }
// // };


















// export interface Meeting {
//   id: number;
//   name: string;
//   date: string;
//   userIds?: number[];
// }

// export interface MeetingPostDTO {
//   name: string;
//   date: string;
//   userIds?: number[];
// }

// const API_URL = "https://localhost:7214/api/Meeting"; // ודאי שזה ה-API הנכון שלך

// export async function fetchMeetings(): Promise<Meeting[]> {
//   const response = await fetch(API_URL);
//   if (!response.ok) {
//       throw new Error("Failed to fetch meetings");
//   }
//   return response.json();
// }

// export async function addMeeting(meeting: MeetingPostDTO): Promise<Meeting | null> {
//   const response = await fetch(API_URL, {
//       method: "POST",
//       headers: { "Content-Type": "application/json" },
//       body: JSON.stringify(meeting),
//   });

//   if (!response.ok) {
//       console.error("Error adding meeting");
//       return null;
//   }

//   return response.json();
// }




import axios from "axios";
import { MeetingPostDTO, Meeting } from "./meetingTypes";

const API_URL = "https://localhost:7214/api/Meeting"; // עדכן לכתובת ה-API שלך

const getAuthToken = () => localStorage.getItem("token");

export const fetchMeetings = async (): Promise<Meeting[]> => {
  try {
    // /Admin kvuxh; tjrh BASEURL בשורה מתחת
    const response = await axios.get<Meeting[]>(`${API_URL}`, {
      headers: {
        Authorization: `Bearer ${getAuthToken()}`,
      },
    });
    return response.data;
  } catch (error) {
    console.error("Error fetching meetings:", error);
    return [];
  }
};


export async function addMeeting(meeting: MeetingPostDTO): Promise<Meeting | null> {
    try {
        const response = await fetch(API_URL, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(meeting),
        });

        if (!response.ok) {
            const errorMessage = await response.text();
            console.error("❌ Error adding meeting:", errorMessage);
            return null;
        }

        return await response.json();
    } catch (error) {
        console.error("❌ Error adding meeting:", error);
        return null;
    }
}

