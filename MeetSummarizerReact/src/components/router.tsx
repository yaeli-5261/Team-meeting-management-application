import { createBrowserRouter, Outlet } from "react-router-dom"; // תיקון: שינוי ל-"react-router-dom"
import HomePage from "./Pages/HomePage";
import Layout from "./Layout";
import FileUploader from "./FileUploader";
import MeetingsPage from "./Pages/MeetingsPage";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <Layout />,
        children: [
            { path: "home", element: <><HomePage /><Outlet /></> }, 
            { path: "FileUploader", element: <><FileUploader /><Outlet /></> },
            { path: "MeetingList", element: <><MeetingsPage /><Outlet /></> }, 
        ],
       
    },
]);
