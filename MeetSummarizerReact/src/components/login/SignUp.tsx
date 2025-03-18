import React, { useState } from "react";
import { Button, TextField, Box } from "@mui/material";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import axios from "axios";
// import { loginUser } from "../UserRedux/authSlice";
// import axios from "axios";
// import { useNavigate } from "react-router-dom";

const API_URL = "https://your-api.com/api/auth"; // עדכן את ה-API שלך

const SignUp = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [name, setName] = useState("");
    const [error, setError] = useState("");
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const response = await axios.post(`${API_URL}/signup`, { name, email, password });
            if (response.data.token) {
                dispatch(loginUser({ email, password }));
                navigate("/dashboard");
            }
        } catch (error: any) {
            setError(error.response?.data?.message || "Signup failed");
        }
    };

    return (
        <Box component="form" onSubmit={handleSubmit} sx={{ display: "flex", flexDirection: "column", gap: 2 }}>
            <TextField label="Name" value={name} onChange={(e) => setName(e.target.value)} required fullWidth />
            <TextField label="Email" type="email" value={email} onChange={(e) => setEmail(e.target.value)} required fullWidth />
            <TextField label="Password" type="password" value={password} onChange={(e) => setPassword(e.target.value)} required fullWidth />
            <Button type="submit" variant="contained" color="primary">
                Sign Up
            </Button>
            {error && <p style={{ color: "red" }}>{error}</p>}
        </Box>
    );
};

export default SignUp;
