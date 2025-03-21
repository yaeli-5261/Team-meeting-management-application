import React, { useState } from "react";
import { Button, TextField, Box } from "@mui/material";
import { useDispatch, useSelector } from "react-redux";
// import { loginUser } from "../UserRedux/authSlice";
// import { RootState } from "../UserRedux/reduxStore";
import { useNavigate } from "react-router-dom";
import { AppDispatch, RootState } from "../UserRedux/reduxStore";
// import loginUser from "../UserRedux/authSlice";  // ✅ ייבוא הפונקציה
import { signIn } from "../UserRedux/authSlice";

const SignIn = () => {
    const [name, setName] = useState("");
    const [password, setPassword] = useState("");
    const dispatch = useDispatch<AppDispatch>();
    const navigate = useNavigate();
    const { loading, error } = useSelector((state: RootState) => state.Auth);
    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        dispatch(signIn({ userName:name, password :password})).then((result: any) => {
            if (result.meta.requestStatus === "fulfilled") {
                navigate("/FileUploader");
            }
        });
    };

    return (
        <Box component="form" onSubmit={handleSubmit} sx={{ display: "flex", flexDirection: "column", gap: 2 }}>
            <TextField
                label="Name"
                type="text"
                value={name}
                onChange={(e:any) => setName(e.target.value)}
                required
                fullWidth
            />
            <TextField
                label="Password"
                type="password"
                value={password}
                onChange={(e:any) => setPassword(e.target.value)}
                required
                fullWidth
            />
            <Button type="submit" variant="contained" color="primary" disabled={loading}>
                {loading ? "Signing in..." : "Sign In"}
            </Button>
            {error && <p style={{ color: "red" }}>{error}</p>}


       
        </Box>


    );
};

export default SignIn;
