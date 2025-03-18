import React, { useState } from "react";
import { Button, TextField, Box } from "@mui/material";
import { useDispatch, useSelector } from "react-redux";
// import { loginUser } from "../UserRedux/authSlice";
// import { RootState } from "../UserRedux/reduxStore";
import { useNavigate } from "react-router-dom";
import { RootState } from "../UserRedux/reduxStore";
// import loginUser from "../UserRedux/authSlice";  // ✅ ייבוא הפונקציה
import { signIn } from "../UserRedux/authSlice";

const SignIn = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const { loading, error } = useSelector((state: RootState) => state.Auth);
    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        dispatch(signIn({ email, password })).then((result: any) => {
            if (result.meta.requestStatus === "fulfilled") {
                navigate("/dashboard");
            }
        });
    };

    return (
        <Box component="form" onSubmit={handleSubmit} sx={{ display: "flex", flexDirection: "column", gap: 2 }}>
            <TextField
                label="Email"
                type="email"
                value={email}
                onChange={(e:any) => setEmail(e.target.value)}
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
