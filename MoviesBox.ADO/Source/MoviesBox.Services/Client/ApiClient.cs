using System;
using System.Collections.Generic;
using RestSharp;

namespace MoviesBox.Services.Client
{
    public class ApiClient
    {
      /// <summary>
      /// Gets or sets the RestClient.
      /// </summary>
      /// <value>An instance of the RestClient</value>
      public RestClient RestClient { get; set; }

      /// <summary>
      /// Gets the default header.
      /// </summary>
      public Dictionary<string, string> DefaultHeader { get; private set; }

      /// <summary>
      /// Initializes a new instance of the <see cref="ApiClient" /> class.
      /// </summary>
      /// <param name="basePath">The base path.</param>
      public ApiClient(string basePath)
      {
        DefaultHeader = new Dictionary<string, string>();
        RestClient = new RestClient(basePath);
      }

      /// <summary>
      /// Makes the HTTP request (Sync).
      /// </summary>
      /// <param name="path">URL path.</param>
      /// <param name="method">HTTP method.</param>
      /// <param name="queryParams">Query parameters.</param>
      /// <param name="postBody">HTTP body (POST request).</param>
      /// <param name="headerParams">Header parameters.</param>
      /// <param name="formParams">Form parameters.</param>
      /// <param name="fileParams">File parameters.</param>
      /// <param name="authSettings">Authentication settings.</param>
      /// <returns>Object</returns>
      public Object CallApi(
        string path,
        RestSharp.Method method,
        Dictionary<string, string> queryParams,
        Dictionary<string, string> headerParams,
        Dictionary<string, string> formParams,
        string postBody)
      {
        var request = new RestRequest(path, method);

        // add default header, if any
        foreach (var header in DefaultHeader)
        {
          request.AddHeader(header.Key, header.Value);
        }

        // add header parameter, if any
        foreach (var param in headerParams)
        {
          request.AddHeader(param.Key, param.Value);
        }

        // add query parameter, if any
        foreach (var param in queryParams)
        {
          request.AddParameter(param.Key, param.Value, ParameterType.QueryString);
        }

        // add form parameter, if any
        foreach (var param in formParams)
        {
          request.AddParameter(param.Key, param.Value, ParameterType.GetOrPost);
        }

        // http body (model) parameter
        if (postBody != null)
        {
          request.AddParameter("application/json", postBody, ParameterType.RequestBody);
        }

        // TODO
        LogRequest(path, method, queryParams, headerParams, formParams, postBody);

        IRestResponse response = RestClient.Execute(request);

        // TODO
        LogResponse(response);

        return response;
      }

      /// <summary>
      /// Logs the request.
      /// </summary>
      /// <param name="path">The path.</param>
      /// <param name="method">The method.</param>
      /// <param name="queryParams">The query parameters.</param>
      /// <param name="headerParams">The header parameters.</param>
      /// <param name="formParams">The form parameters.</param>
      /// <param name="postBody">The post body.</param>
      private void LogRequest(string path, Method method, Dictionary<string, string> queryParams, Dictionary<string, string> headerParams, Dictionary<string, string> formParams, string postBody)
      {
        // TODO
      }

      /// <summary>
      /// Logs the response.
      /// </summary>
      /// <param name="response">The response.</param>
      private void LogResponse(IRestResponse response)
      {
        // TODO
      }
    }
}
