import { configureStore } from "@reduxjs/toolkit";
import authReducer from "./authSlice"; // עדכון לשם הנכון של ה-slice

const store = configureStore({
    reducer: {
        Auth: authReducer // שינוי שם ל-authReducer בהתאם לקובץ החדש
    }
});

// טיפוסים עבור Redux
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;
