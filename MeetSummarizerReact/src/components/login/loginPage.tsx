import { Button, Grid2 } from "@mui/material";
import SignIn from "./SignIn";
import SignUp from "./SignUp";
import { useContext, useState } from "react";
import { useSelector } from "react-redux";
import { RootState } from "../UserRedux/reduxStore";
import UserDetails from "./UserDetails";
import { IsloginContext } from "../Layout";

const LoginPage = () => {
    const [showLogin, setShowLogin] = useState(false);
    const [showRegister, setShowRegister] = useState(false);
    const user = useSelector((state: RootState) => state.Auth.user);
    const [isLogin] = useContext(IsloginContext);

    const handleLoginClick = () => {
        setShowLogin(true);
        setShowRegister(false);
    };

    const handleRegisterClick = () => {
        setShowRegister(true);
        setShowLogin(false);
    };

    return (
        <Grid2 container spacing={2}>
            <Grid2 size={2}>
                <div style={{ display: "flex", flexDirection: "column", alignItems: "center" }}>
                    {user?.token ? (
                        <UserDetails />
                    ) : (
                        <>
                            <div style={{ display: "flex", gap: "10px", marginBottom: "10px" }}>
                                <Button color="primary" variant="contained" onClick={handleLoginClick}>
                                    Sign in
                                </Button>
                                <Button color="primary" variant="contained" onClick={handleRegisterClick}>
                                    Sign up
                                </Button>
                            </div>
                            {showLogin && <SignIn />}
                            {showRegister && <SignUp />}
                        </>
                    )}
                </div>
            </Grid2>
        </Grid2>
    );
};

export default LoginPage;
