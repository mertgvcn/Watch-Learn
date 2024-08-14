import { createEntityAdapter } from "@reduxjs/toolkit";
import { RootState } from "../../app/store";
import { CourseViewModel } from "../../../models/viewModels/CourseViewModel";

export const attendedCoursesAdapter = createEntityAdapter({
    selectId: (course: CourseViewModel) => course.id
})

const attendedCourseSelectors = attendedCoursesAdapter.getSelectors((state: RootState) => state.currentStudent.attendedCourses)
export const selectStudentAttendedCourses = (state: RootState) => attendedCourseSelectors.selectAll(state)
export const selectStudentAttendedCourseById = (state: RootState, courseId: number) => attendedCourseSelectors.selectById(state, courseId)
export const selectStudentAttendedCoursesLoading = (state: RootState) => state.currentStudent.attendedCourses.loading

export const selectIsStudentAttendedToCourse = (state: RootState) => state.currentStudent.isAttendedToCourse.isAttended
export const selectIsStudentAttendedToCourseLoading = (state: RootState) => state.currentStudent.isAttendedToCourse.loading