//redux
import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { GetCoursesAttendedByCurrentStudent, IsCurrentStudentAttendedToCourse } from "./thunks";
import { attendedCoursesAdapter } from "./selectors";
//models
import { CourseViewModel } from "../../../models/viewModels/CourseViewModel";

export const currentStudentSlice = createSlice({
    name: 'currentStudentSlice',
    initialState: {
        attendedCourses: attendedCoursesAdapter.getInitialState({
            loading: false
        }),
        isAttendedToCourse: {
            isAttended: false,
            loading: false
        }
    },
    reducers: {},
    extraReducers(builder) {
        builder
            .addCase(GetCoursesAttendedByCurrentStudent.pending, (state) => {
                state.attendedCourses.loading = true
            })
            .addCase(GetCoursesAttendedByCurrentStudent.fulfilled, (state, action: PayloadAction<CourseViewModel[]>) => {
                attendedCoursesAdapter.setAll(state.attendedCourses, action.payload)
                state.attendedCourses.loading = false
            })
            .addCase(GetCoursesAttendedByCurrentStudent.rejected, (state) => {
                state.attendedCourses.loading = false
            })

            .addCase(IsCurrentStudentAttendedToCourse.pending, (state) => {
                state.isAttendedToCourse.loading = true
            })
            .addCase(IsCurrentStudentAttendedToCourse.fulfilled, (state, action: PayloadAction<boolean>) => {
                state.isAttendedToCourse.isAttended = action.payload
                state.isAttendedToCourse.loading = false
            })
            .addCase(IsCurrentStudentAttendedToCourse.rejected, (state) => {
                state.isAttendedToCourse.loading = false
            })
    },
})

export const { } = currentStudentSlice.actions
export default currentStudentSlice.reducer