import grpc
import grpcDemo_pb2
import grpcDemo_pb2_grpc
from concurrent import futures

class PyServer(grpcDemo_pb2_grpc.GrpcDemoServicer):
    def GetMessgae(self,requet,context):
        return grpcDemo_pb2.Response(info='Hello')
def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    grpcDemo_pb2_grpc.add_GrpcDemoServicer_to_server(PyServer(),server)
    server.add_insecure_port('127.0.0.1:5001')
    server.start()
    server.wait_for_termination()


if __name__ == '__main__':
    #logging.basicConfig()
    serve()