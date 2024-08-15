//redux
import { createEntityAdapter } from "@reduxjs/toolkit"
import { RootState } from "../../app/store"
//models
import { CourseViewModel } from "../../../models/viewModels/CourseViewModel"

//courses
export const coursesAdapter = createEntityAdapter({
    selectId: (course: CourseViewModel) => course.id
 })

const coursesSelectors = coursesAdapter.getSelectors((state: RootState) => state.course.courses)
export const selectCourses = (state: RootState) => coursesSelectors.selectAll(state)
export const selectCoursesLoading = (state: RootState) => state.course.courses.loading

