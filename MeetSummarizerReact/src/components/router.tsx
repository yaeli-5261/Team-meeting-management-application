import { createBrowserRouter, Outlet } from "react-router-dom"; // תיקון: שינוי ל-"react-router-dom"
import HomePage from "./HomePage";
import Layout from "./Layout";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <Layout />,
        children: [
            { path: "home", element: <><HomePage /><Outlet /></> }, // שינוי לנתיב "home"
        ],
    },
]);
