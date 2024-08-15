import { createEntityAdapter } from "@reduxjs/toolkit";
import { RootState } from "../../app/store";
//models
import { CurrentStudentCourseViewModel } from "../../../models/viewModels/CurrentStudentCourseViewModel";

//currentStudentCourses
export const currentStudentCoursesAdapter = createEntityAdapter({
    selectId: (myCourse: CurrentStudentCourseViewModel) => myCourse.id
})
export const currentStudentCoursesSelectors = currentStudentCoursesAdapter.getSelectors((state: RootState) => state.student.currentStudentCourses)
export const selectCurrentStudentCourses = (state: RootState) => currentStudentCoursesSelectors.selectAll(state)
export const selectCurrentStudentCoursesLoading = (state: RootState) => state.student.currentStudentCourses.loading

//isAttendedToCourse
export const selectIsStudentAttendedToCourse = (state: RootState) => state.student.isAttendedToCourse.currentState
export const selectIsStudentAttendedToCourseLoading = (state: RootState) => state.student.isAttendedToCourse.loading