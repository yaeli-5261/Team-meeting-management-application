import { Outlet } from "react-router-dom";
import NavBar from "./NavBar";
import { createContext, useState } from "react";
import LoginPage from "./login/loginPage";

export const IsloginContext = createContext<any>(undefined);

const Layout = () => {
    const [islogin, setIslogin] = useState(false);

    return (
        <IsloginContext.Provider value={[islogin, setIslogin]}>
            <NavBar />
            <div style={{
                display: "flex", position: "absolute", alignItems: "center",
                top: "5%", left: "5%"
            }}>
                <LoginPage />
            </div>
            <Outlet />
        </IsloginContext.Provider>
    );
};

export default Layout;
