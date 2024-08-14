//redux
import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { GetAllCourses, GetCourseById } from "./thunks";
import { courseAdapter } from "./selectors";
//models
import { CourseViewModel } from "../../../models/viewModels/CourseViewModel";

export const courseSlice = createSlice({
    name: 'course',
    initialState: courseAdapter.getInitialState({
        loading: false,
    }),
    reducers: {},
    extraReducers(builder) {
        builder
            .addCase(GetAllCourses.pending, (state) => {
                state.loading = true
            })
            .addCase(GetAllCourses.fulfilled, (state, action: PayloadAction<CourseViewModel[]>) => {
                courseAdapter.setAll(state, action.payload)
                state.loading = false
            })
            .addCase(GetAllCourses.rejected, (state) => {
                state.loading = false
            })
            
            .addCase(GetCourseById.pending, (state) => {
                state.loading = true
            })
            .addCase(GetCourseById.fulfilled, (state, action: PayloadAction<CourseViewModel>) => {
                courseAdapter.setOne(state, action.payload)
                state.loading = false
            })
            .addCase(GetCourseById.rejected, (state) => {
                state.loading = false
            })
    }
})

export const { } = courseSlice.actions
export default courseSlice.reducer