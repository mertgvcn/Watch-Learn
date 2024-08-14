//redux
import { createEntityAdapter } from "@reduxjs/toolkit"
import { RootState } from "../../app/store"
//models
import { CourseViewModel } from "../../../models/viewModels/CourseViewModel"

export const courseAdapter = createEntityAdapter({
    selectId: (course: CourseViewModel) => course.id
})

const courseSelectors = courseAdapter.getSelectors((state: RootState) => state.course.courses)
export const selectCourses = (state: RootState) => courseSelectors.selectAll(state)
export const selectCourseById = (state: RootState, id: number) => courseSelectors.selectById(state, id)
export const selectCoursesLoading = (state: RootState) => state.course.courses.loading