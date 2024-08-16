//redux
import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { GetAllCourses, GetCourseDetailById } from "./thunks";
import { coursesAdapter } from "./selectors";
//models
import { CourseViewModel } from "../../../models/viewModels/CourseViewModel";
import { CourseDetailViewModel } from "../../../models/viewModels/CourseDetailViewModel";

interface InitialStateType {
    courses: ReturnType<typeof coursesAdapter.getInitialState> & { loading: boolean };
    courseDetail: {
        currentState: CourseDetailViewModel | null;
        loading: boolean;
    };
}

const initialState: InitialStateType = {
    courses: coursesAdapter.getInitialState({
        loading: false,
    }),
    courseDetail: {
        currentState: null,
        loading: false,
    }
}

export const courseSlice = createSlice({
    name: 'course',
    initialState,
    reducers: {},
    extraReducers(builder) {
        builder
            .addCase(GetAllCourses.pending, (state) => {
                state.courses.loading = true
            })
            .addCase(GetAllCourses.fulfilled, (state, action: PayloadAction<CourseViewModel[]>) => {
                coursesAdapter.setAll(state.courses, action.payload)
                state.courses.loading = false
            })
            .addCase(GetAllCourses.rejected, (state) => {
                state.courses.loading = false
            })

            .addCase(GetCourseDetailById.pending, (state) => {
                state.courseDetail.loading = true
            })
            .addCase(GetCourseDetailById.fulfilled, (state, action: PayloadAction<CourseDetailViewModel>) => {
                state.courseDetail.currentState = action.payload
                state.courseDetail.loading = false
            })
            .addCase(GetCourseDetailById.rejected, (state) => {
                state.courseDetail.loading = false
            })
    }
})

export const { } = courseSlice.actions
export default courseSlice.reducer