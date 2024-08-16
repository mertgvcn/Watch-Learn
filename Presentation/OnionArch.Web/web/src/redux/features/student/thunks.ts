import { createAsyncThunk } from "@reduxjs/toolkit";
//apis
import StudentAPI from "../../../APIs/StudentAPI";
import CourseAPI from "../../../APIs/CourseAPI";
//models
import { CurrentStudentCourseViewModel } from "../../../models/viewModels/CurrentStudentCourseViewModel";

export const GetCurrentStudentCourses = createAsyncThunk<CurrentStudentCourseViewModel[]>(
    'Course/GetCurrentStudentCourses',
    async () => {
        const response = await CourseAPI.GetCurrentStudentCourses()
        return response.data
    }
)

export const IsCurrentStudentAttendedToCourse = createAsyncThunk<boolean, number>(
    'Student/IsCurrentStudentAttendedToCourse',
    async (courseId: number) => {
        const response = await StudentAPI.IsCurrentStudentAttendedToCourse(courseId)
        return response.data
    }
)