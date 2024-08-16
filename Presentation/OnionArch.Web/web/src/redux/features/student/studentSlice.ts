//redux
import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { GetCurrentStudentCourses, IsCurrentStudentAttendedToCourse } from "./thunks";
import { currentStudentCoursesAdapter } from "./selectors";
//models
import { CurrentStudentCourseViewModel } from "../../../models/viewModels/CurrentStudentCourseViewModel";

interface InitialStateType {
    currentStudentCourses: ReturnType<typeof currentStudentCoursesAdapter.getInitialState> & { loading: boolean };
    isAttendedToCourse: {
        currentState: boolean | null;
        loading: boolean;
    };
}

const initialState: InitialStateType = {
    currentStudentCourses: currentStudentCoursesAdapter.getInitialState({
        loading: false,
    }),
    isAttendedToCourse: {
        currentState: null,
        loading: false,
    }
}

export const studentSlice = createSlice({
    name: 'studentSlice',
    initialState,
    reducers: {},
    extraReducers(builder) {
        builder
            .addCase(GetCurrentStudentCourses.pending, (state) => {
                state.currentStudentCourses.loading = true
            })
            .addCase(GetCurrentStudentCourses.fulfilled, (state, action: PayloadAction<CurrentStudentCourseViewModel[]>) => {
                currentStudentCoursesAdapter.setAll(state.currentStudentCourses, action.payload)
                state.currentStudentCourses.loading = false
            })
            .addCase(GetCurrentStudentCourses.rejected, (state) => {
                state.currentStudentCourses.loading = false
            })

            .addCase(IsCurrentStudentAttendedToCourse.pending, (state) => {
                state.isAttendedToCourse.loading = true
            })
            .addCase(IsCurrentStudentAttendedToCourse.fulfilled, (state, action: PayloadAction<boolean>) => {
                state.isAttendedToCourse.currentState = action.payload
                state.isAttendedToCourse.loading = false
            })
            .addCase(IsCurrentStudentAttendedToCourse.rejected, (state) => {
                state.isAttendedToCourse.loading = false
            })
    },
})

export const { } = studentSlice.actions
export default studentSlice.reducer