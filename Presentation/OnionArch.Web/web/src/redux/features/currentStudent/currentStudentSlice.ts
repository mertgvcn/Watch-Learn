import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IsCurrentStudentAttendedToCourse } from "./thunks";

export const currentStudentSlice = createSlice({
    name: 'currentStudentSlice',
    initialState: {
        isAttendedToCourse: false,
        loading: false
    },
    reducers: {},
    extraReducers(builder) {
        builder
            .addCase(IsCurrentStudentAttendedToCourse.pending, (state) => {
                state.loading = true
            })
            .addCase(IsCurrentStudentAttendedToCourse.fulfilled, (state, action: PayloadAction<boolean>) => {
                state.isAttendedToCourse = action.payload
                state.loading = false
            })
            .addCase(IsCurrentStudentAttendedToCourse.rejected, (state) => {
                state.loading = false
            })
    },
})

export const { } = currentStudentSlice.actions
export default currentStudentSlice.reducer