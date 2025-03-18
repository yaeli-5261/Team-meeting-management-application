import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import axios from "axios";

interface User {
    id?: string;
    name: string;
    email?: string;
    password: string;
    roleName?: string;
    token?: string;
}

const API_URL = "https://localhost:7214/api/Auth";

// פעולה להתחברות
export const signIn = createAsyncThunk(
    "Auth/login",
    async (user: { name: string; password: string }, thunkAPI) => {
        try {
            const res = await axios.post(`${API_URL}/Login`, {
                Name: user.name,
                Password: user.password
            });
            return res.data; // מניח שהשרת מחזיר { token, user }
        } catch (err: any) {
            return thunkAPI.rejectWithValue(err.response?.data || "Failed to sign in");
        }
    }
);

// פעולה לרישום משתמש חדש
export const signUp = createAsyncThunk(
    "Auth/register",
    async (user: { name: string; email: string; password: string; roleName: string }, thunkAPI) => {
        try {
            const res = await axios.post(`${API_URL}/Register`, {
                Name: user.name,
                Email: user.email,
                Password: user.password,
                RoleName: user.roleName
            });
            return res.data; // מניח שהשרת מחזיר { token, user }
        } catch (err: any) {
            return thunkAPI.rejectWithValue(err.response?.data || "Failed to sign up");
        }
    }
);

// טעינת משתמש מה-Session Storage אם קיים
const loadUserFromSession = (): User | null => {
    const userData = sessionStorage.getItem("user");
    return userData ? JSON.parse(userData) : null;
};

// יצירת Slice לניהול המצב של המשתמש
const authSlice = createSlice({
    name: "Auth",
    initialState: {
        user: loadUserFromSession() || ({} as User),
        loading: false,
        error: ""
    },
    reducers: {
        logout: (state) => {
            state.user = {} as User;
            sessionStorage.removeItem("user");
        }
    },
    extraReducers: (builder) => {
        builder
            .addCase(signIn.pending, (state) => {
                state.loading = true;
                state.error = "";
            })
            .addCase(signIn.fulfilled, (state, action: PayloadAction<{ token: string; user: User }>) => {
                state.loading = false;
                state.user = action.payload.user;
                state.user.token = action.payload.token;
                sessionStorage.setItem("user", JSON.stringify(state.user));
            })
            .addCase(signIn.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload as string;
            })
            .addCase(signUp.pending, (state) => {
                state.loading = true;
                state.error = "";
            })
            .addCase(signUp.fulfilled, (state, action: PayloadAction<{ token: string; user: User }>) => {
                state.loading = false;
                state.user = action.payload.user;
                state.user.token = action.payload.token;
                sessionStorage.setItem("user", JSON.stringify(state.user));
            })
            .addCase(signUp.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload as string;
            });
    }
});

export const { logout } = authSlice.actions;
export default authSlice.reducer;
