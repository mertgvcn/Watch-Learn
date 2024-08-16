import { AxiosResponse } from "axios";
import { BaseAPI } from "./BaseAPI";
//models

class StudentAPI extends BaseAPI {
    private controllerExtension: string = "/Student"

    constructor() {
        super()
    }

    public async GetCoursesAttendedByCurrentStudent(): Promise<AxiosResponse> {
        return await this.get(this.controllerExtension + '/GetCoursesAttendedByCurrentStudent')
    }

    public async IsCurrentStudentAttendedToCourse(courseId: number): Promise<AxiosResponse> {
        return await this.get(this.controllerExtension + '/IsCurrentStudentAttendedToCourse', { courseId })
    }
}

export default new StudentAPI()