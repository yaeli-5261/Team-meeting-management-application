// import { useState } from "react";
// import { addMeeting, Meeting } from "../Api/meetingService";

// interface AddMeetingFormProps {
//     onMeetingAdded: (meeting: Meeting) => void;
// }

// const AddMeetingForm = ({ onMeetingAdded }: AddMeetingFormProps) => {
//     const [name, setName] = useState("");
//     const [date, setDate] = useState("");
//     const [userIds, setUserIds] = useState<number[]>([]); // שדה חדש

//     const handleSubmit = async (e: React.FormEvent) => {
//         e.preventDefault();

//         if (!date) {
//             console.error("Error: תאריך אינו תקין");
//             return;
//         }

//         const parsedDate = new Date(date);
//         if (isNaN(parsedDate.getTime())) {
//             console.error("Error: תאריך בפורמט שגוי");
//             return;
//         }

//         // שליחת התאריך בפורמט מלא (YYYY-MM-DDTHH:mm:ssZ)
//         const formattedDate = parsedDate.toISOString();

//         const newMeeting: Meeting = {
            
//             name,
//             date: formattedDate,
//             ...(userIds.length > 0 && { userIds }) // שולח userIds רק אם יש ערכים
//             ,
//             id: 0
//         };
        
//         const result = await addMeeting(newMeeting);

//         if (result) {
//             onMeetingAdded(result);
//             setName("");
//             setDate("");
//             setUserIds([]);
//         }
//     };

//     return (
//         <form onSubmit={handleSubmit} className="p-4 border rounded-lg shadow-md">
//             <h3 className="text-lg font-bold mb-2">הוספת ישיבה חדשה</h3>
//             <input
//                 type="text"
//                 placeholder="שם הישיבה"
//                 value={name}
//                 onChange={(e) => setName(e.target.value)}
//                 className="w-full p-2 border rounded-md mb-2"
//             />
//             <input
//                 type="datetime-local" // שינוי מ-`date` ל-`datetime-local`
//                 value={date}
//                 onChange={(e) => setDate(e.target.value)}
//                 className="w-full p-2 border rounded-md mb-2"
//             />
//             <button type="submit" className="bg-blue-500 text-white px-4 py-2 rounded-md">
//                 הוספה
//             </button>

//         </form>
    
//     );
// };

// export default AddMeetingForm;




// import { useState } from "react";
// import { addMeeting, MeetingPostDTO, Meeting } from "../Api/meetingService";

// interface AddMeetingFormProps {
//     onMeetingAdded: (meeting: Meeting) => void;
// }

// const AddMeetingForm = ({ onMeetingAdded }: AddMeetingFormProps) => {
//     const [name, setName] = useState("");
//     const [date, setDate] = useState("");
//     const [userIds, setUserIds] = useState<number[]>([]);
//     const [message, setMessage] = useState<string | null>(null);

//     const handleSubmit = async (e: React.FormEvent) => {
//         e.preventDefault();

//         if (!date) {
//             setMessage("❌ יש להזין תאריך תקין");
//             return;
//         }

//         const parsedDate = new Date(date);
//         if (isNaN(parsedDate.getTime())) {
//             setMessage("❌ תאריך בפורמט שגוי");
//             return;
//         }

//         const formattedDate = parsedDate.toISOString();

//         const newMeeting: MeetingPostDTO = {
//             name,
//             date: formattedDate,
//             userIds: userIds.length > 0 ? userIds : [],
//         };

//         const result = await addMeeting(newMeeting);

//         if (result) {
//             onMeetingAdded(result);
//             setMessage("✅ הישיבה נוספה בהצלחה!");
//             setName("");
//             setDate("");
//             setUserIds([]);
//         } else {
//             setMessage("❌ שגיאה בהוספת ישיבה, נסה שוב.");
//         }
//     };

//     return (
//         <form onSubmit={handleSubmit} className="p-4 border rounded-lg shadow-md">
//             <h3 className="text-lg font-bold mb-2">הוספת ישיבה חדשה</h3>

//             {message && <p className="mb-2 text-sm font-bold">{message}</p>}

//             <input
//                 type="text"
//                 placeholder="שם הישיבה"
//                 value={name}
//                 onChange={(e) => setName(e.target.value)}
//                 className="w-full p-2 border rounded-md mb-2"
//             />
//             <input
//                 type="datetime-local"
//                 value={date}
//                 onChange={(e) => setDate(e.target.value)}
//                 className="w-full p-2 border rounded-md mb-2"
//             />
//             <button type="submit" className="bg-blue-500 text-white px-4 py-2 rounded-md">
//                 הוספה
//             </button>
//         </form>
//     );
// };

// export default AddMeetingForm;





import { useState } from "react";
import { Meeting, MeetingPostDTO } from "../Api/meetingTypes";
import { addMeeting } from "../Api/meetingService";
// import { addMeeting } from "../api/meetingService";
// import { MeetingPostDTO, Meeting } from "../api/meetingTypes";

interface AddMeetingFormProps {
    onMeetingAdded: (meeting: Meeting) => void;
}

const AddMeetingForm = ({ onMeetingAdded }: AddMeetingFormProps) => {
    const [name, setName] = useState("");
    const [date, setDate] = useState("");
    const [userIds, setUserIds] = useState<number[]>([]);
    const [message, setMessage] = useState<string | null>(null);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        if (!name.trim()) {
            setMessage("❌ יש להזין שם ישיבה");
            return;
        }

        if (!date) {
            setMessage("❌ יש להזין תאריך תקין");
            return;
        }

        const formattedDate = new Date(date).toISOString();

        const newMeeting: MeetingPostDTO = {
            name,
            date: formattedDate,
            userIds,
        };

        console.log("📤 שולח פגישה לשרת:", JSON.stringify(newMeeting));

        const result = await addMeeting(newMeeting);

        if (result) {
            onMeetingAdded(result);
            setMessage("✅ הישיבה נוספה בהצלחה!");
            setName("");
            setDate("");
            setUserIds([]);
        } else {
            setMessage("❌ שגיאה בהוספת ישיבה, נסה שוב.");
        }
    };

    return (
        <form onSubmit={handleSubmit} className="p-4 border rounded-lg shadow-md">
            <h3 className="text-lg font-bold mb-2">הוספת ישיבה חדשה</h3>

            {message && <p className="mb-2 text-sm font-bold">{message}</p>}

            <input
                type="text"
                placeholder="שם הישיבה"
                value={name}
                onChange={(e) => setName(e.target.value)}
                className="w-full p-2 border rounded-md mb-2"
            />
            <input
                type="datetime-local"
                value={date}
                onChange={(e) => setDate(e.target.value)}
                className="w-full p-2 border rounded-md mb-2"
            />
            <button type="submit" className="bg-blue-500 text-white px-4 py-2 rounded-md">
                הוספה
            </button>
        </form>
    );
};

export default AddMeetingForm;
