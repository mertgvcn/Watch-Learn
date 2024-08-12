//redux
import { createEntityAdapter } from "@reduxjs/toolkit"
import { RootState, store } from "../../app/store"
//models
import { CourseViewModel } from "../../../models/viewModels/CourseViewModel"

export const courseAdapter = createEntityAdapter({
    selectId: (course: CourseViewModel) => course.id
})

const courseSelectors = courseAdapter.getSelectors((state: RootState) => state.course)

export const selectCourses = (state: RootState) => courseSelectors.selectAll(state)
export const selectCourseById = (state: RootState, id: number) => courseSelectors.selectById(state, id)